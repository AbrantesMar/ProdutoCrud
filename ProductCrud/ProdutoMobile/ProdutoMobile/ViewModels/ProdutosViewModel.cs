using ProdutoMobile.Helpers;
using ProdutoMobile.Models;
using ProdutoMobile.Views;
using ProdutoMobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProdutoMobile.ViewModels
{
    public class ProdutosViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ProdutoModel> Produtos { get; set; }
        public Command LoadProdutosCommand { get; set; }

        public ProdutosViewModel()
        {
            Produtos = new ObservableRangeCollection<ProdutoModel>();
            LoadProdutosCommand = new Command(async () => await ExecuteLoadProdutosCommand());
            
            MessagingCenter.Subscribe<NewProdutoPage, ProdutoModel>(this, "AddProduto", async (obj, item) =>
            {
                var _produtoModel = item as ProdutoModel;
                _produtoModel.DataDeCadastro = DateTime.Now;
                Produtos.Add(_produtoModel);
                await DataStore.AddItemAsync(_produtoModel);
            });
        }

        async Task ExecuteLoadProdutosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Produtos.Clear();
                var items = await DataStore.GetItemsAsync(true);
                //var itemsRequest = await GetJson(null, "ListProdutos");
                //foreach (var item in items)
                //{
                //    itemsRequest.Add(item);
                //}
                Produtos.ReplaceRange(items);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }

        //private static string UriApi { get { return "http://localhost:57116/api/"; } }

        //public static async Task<List<ProdutoModel>> GetJson(int? id, string uri)
        //{
        //    try
        //    {
        //        #region RequestJson
        //        System.Net.Http.HttpClient httpClientTeste = new System.Net.Http.HttpClient();
        //        httpClientTeste.DefaultRequestHeaders.Accept.TryParseAdd("application/json");
        //        //UriApi
        //        var uriId = UriApi + uri;
        //        if (id != null || id != 0)
        //        {
        //            uriId += id;
        //        }
        //        string ResponseStringTeste = await httpClientTeste.GetStringAsync(new Uri(uriId));
        //        var jsonTeste = JsonConvert.DeserializeObject<List<ProdutoModel>>(ResponseStringTeste);
        //        return (List<ProdutoModel>)jsonTeste;
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}
        
    }
}
