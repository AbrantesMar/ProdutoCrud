﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoMobile.Services
{
	public interface IDataStore<T>
	{
		Task<bool> AddItemAsync(T item);
		Task<bool> UpdateItemAsync(T item);
		Task<bool> DeleteItemAsync(T item);
		Task<T> GetItemAsync(long id);
		Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

		Task InitializeAsync();
		Task<bool> PullLatestAsync();
		Task<bool> SyncAsync();
	}
}
