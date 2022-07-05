/*****************************************************
    文件：ResLoader.cs
    作者：LuoXiaoHei
    邮箱：2906809995@qq.com
    日期：2022/3/17 15:13
    功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace LFramework.Manager
{
	public class ResLoader
	{
		#region API

		/// <summary>
		/// 同步加载资源
		/// </summary>
		/// <param name="assetBundleName">AB包名字</param>
		/// <param name="assetName">资源名字</param>
		/// <typeparam name="T">资源类型</typeparam>
		/// <returns>该资源</returns>
		public T LoadSync<T>(string assetBundleName, string assetName) where T : Object
		{
			return DoLoadSync<T>(assetName, assetBundleName);
		}

		/// <summary>
		/// 同步加载资源
		/// </summary>
		/// <param name="assetName">资源名字</param>
		/// <typeparam name="T">资源类型</typeparam>
		/// <returns>该资源</returns>
		public T LoadSync<T>(string assetName) where T : Object
		{
			return DoLoadSync<T>(assetName);

		}

		/// <summary>
		/// 异步加载资源
		/// </summary>
		/// <param name="assetName">资源名字</param>
		/// <param name="onLoaded">回调函数</param>
		/// <typeparam name="T">资源类型</typeparam>
		public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : Object
		{
			DoLoadAsync(assetName, null, onLoaded);
		}

		/// <summary>
		/// 异步加载资源
		/// </summary>
		/// <param name="assetBundleName">AB包名字</param>
		/// <param name="assetName">资源名字</param>
		/// <param name="onLoaded">回调函数</param>
		/// <typeparam name="T">资源类型</typeparam>
		public void LoadAsync<T>(string assetBundleName, string assetName, Action<T> onLoaded) where T : Object
		{
			DoLoadAsync(assetName, assetBundleName, onLoaded);
		}

		public void ReleaseAll()
		{
			mResRecord.ForEach(loadedAsset => loadedAsset.Release());

			mResRecord.Clear();
		}

		#endregion


		#region Private

		private T DoLoadSync<T>(string assetName, string assetBundleName = null) where T : Object
		{
			var res = GetOrCreateRes(assetName);

			if (res != null)
			{
				switch (res.State)
				{
					case ResState.Loading:
						throw new Exception(string.Format("请不要在异步加载资源 {0} 时，进行 {0} 的同步加载", res.Name));
					case ResState.Loaded:
						return res.Asset as T;
				}
			}

			// 真正加载资源
			res = CreateRes(assetName,assetBundleName);

			res.LoadSync();

			return res.Asset as T;
		}

		private void DoLoadAsync<T>(string assetName, string ownerBundleName, Action<T> onLoaded) where T : Object
		{
			// 查询当前的 资源记录
			var res = GetOrCreateRes(assetName);

			Action<Res> onResLoaded = null;

			onResLoaded = loadedRes =>
			{
				onLoaded(loadedRes.Asset as T);

				res.UnRegisterOnLoadedEvent(onResLoaded);
			};

			if (res != null)
			{
				if (res.State == ResState.Loading)
				{
					res.RegisterOnLoadedEvent(onResLoaded);
				}
				else if (res.State == ResState.Loaded)
				{
					onLoaded(res.Asset as T);
				}

				return;
			}

			// 真正加载资源
			res = CreateRes(assetName, ownerBundleName);

			res.RegisterOnLoadedEvent(onResLoaded);

			res.LoadAsync();
		}


		private List<Res> mResRecord = new List<Res>();

		private Res GetOrCreateRes(string assetName)
		{
			// 查询当前的 资源记录
			var res = GetResFromRecord(assetName);

			if (res != null)
			{
				return res;
			}

			// 查询全局资源池
			res = GetFromResMgr(assetName);

			if (res != null)
			{
				AddRes2Record(res);

				return res;
			}

			return res;
		}

		private Res CreateRes(string assetName, string ownerBundle = null)
		{
			var res = ResFactory.Create(assetName, ownerBundle);

			ResMgr.Instance.SharedLoadedReses.Add(res);

			AddRes2Record(res);

			return res;
		}

		private Res GetResFromRecord(string assetName)
		{
			return mResRecord.Find(loadedAsset => loadedAsset.Name == assetName);
		}

		private Res GetFromResMgr(string assetName)
		{
			return ResMgr.Instance.SharedLoadedReses.Find(loadedAsset => loadedAsset.Name == assetName);
		}

		private void AddRes2Record(Res resFromResMgr)
		{
			mResRecord.Add(resFromResMgr);

			resFromResMgr.Retain();
		}

		#endregion
	}
}
