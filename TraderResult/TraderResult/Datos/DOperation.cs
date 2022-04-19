using System;
using System.Collections.Generic;
using System.Text;
using TraderResult.Models;
using TraderResult.Conection;
using Firebase.Database.Query;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Firebase.Database;
using Syncfusion.Data.Extensions;

namespace TraderResult.Datos

{
    public class DOperation
    {
        #region Variables
        int Contador;
        int CountLosser;
        decimal sumaM;
        #endregion

        #region Methods
        public async Task InsertOperation(Operation parametros)
        {
            await Cconection.firebase
                .Child("Operation")
                .PostAsync(new Operation()
                {
                    Date = parametros.Date,
                    OperationType = parametros.OperationType,
                    Market = parametros.Market,
                    Entry = parametros.Entry,
                    Target = parametros.Target,
                    TypeResult = parametros.TypeResult,
                    Result = parametros.Result
                });
        }
        public async Task<List<Operation>> ShowOperation()
        {
            return (await Cconection.firebase
               .Child("Operation")
               .OnceAsync<Operation>())
               .Select(item => new Operation
               {
                   IdOperation = item.Key,
                   Date = item.Object.Date,
                   OperationType = item.Object.OperationType,
                   Market = item.Object.Market,
                   Entry = item.Object.Entry,
                   Target = item.Object.Target,
                   TypeResult = item.Object.TypeResult,
                   Result = item.Object.Result
               }).ToList();


            //var data = await Task.Run(() => Cconection.firebase
            //    .Child("Operation")
            //    .AsObservable<Operation>()
            //    .AsObservableCollection());
            //return data;
        }
        public async Task<int> CountOperationG()
        {
            var data = (await Cconection.firebase
                .Child("Operation")
                .OnceAsync<Operation>())
                .Select(item => new Operation
                {
                    TypeResult = item.Object.TypeResult,
                    Market = item.Object.Market

                }).Where(a => a.TypeResult == "Ganada" && a.Market == "Sp500");

            int total = 0;
            total = data.Count();
            Contador = total;
            return Contador;
        }
        public async Task<int> CountOperationP()
        {
            var data = (await Cconection.firebase
                .Child("Operation")
                .OnceAsync<Operation>())
                .Select(item => new Operation
                {
                    TypeResult = item.Object.TypeResult,
                    Market = item.Object.Market

                }).Where(b => b.TypeResult == "Perdida" && b.Market == "Sp500");

            int total = 0;
            total = data.Count();
            CountLosser = total;
            return CountLosser;
        }
        public async Task<decimal> SumOperationSp()
        {
            var data = (await Cconection.firebase
                .Child("Operation")
                .OnceAsync<Operation>())
                .Select(item => new Operation
                {
                    Result = item.Object.Result,
                    Market = item.Object.Market

                }).Where(a => a.Market == "Sp500");

            decimal total = 0;
            total = data.Sum(a => Convert.ToDecimal(a.Result));
            sumaM = total;
            return sumaM;
        }

        public async Task<List<Operation>> TopOperation()
        {
            var data = (await Cconection.firebase
                .Child("Operation")
                .OnceAsync<Operation>())
                .Where(x => x.Object.TypeResult == "Ganada")
                .OrderByDescending(a => a.Object.Result)
                .Take(3)
                .Select(item => new Operation
                {
                    Date = item.Object.Date,
                    OperationType = item.Object.OperationType,
                    Market = item.Object.Market,
                    TypeResult = item.Object.TypeResult,
                    Result = item.Object.Result
                }).ToList();
            return data;
        }
        #endregion

    }
}
