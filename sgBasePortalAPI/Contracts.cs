using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sgBasePortalAPI.Helpers;

namespace sgBasePortalAPI
{
    public class Contracts
    {
        const string 
            BaseUrl = @"http://www.base.gov.pt/base2/rest/contratos";

        Func<ContractJson, Contract> 
            transform = (_) => _.ToBaseObject();

        Func<ContractJsonForListedSearch, Contract>
            transformForListedSearch = (_) => _.ToBaseObject();

        public Contracts()
        {
        }

        public Contract Get(
            int id
        )
        {
            return JsonHelper.Get<Contract, ContractJson>(
                BaseUrl,
                id,
                transform
            );
        }

        public async Task<Contract> GetAsync(
            int id
        )
        {
            return await JsonHelper.GetAsync<Contract, ContractJson>(
                BaseUrl,
                id,
                transform
            );
        }

        public IEnumerable<Contract> Get(
            int fromResultIndex, 
            int toResultIndex, 
            List<KeyValuePair<ContractFilterColumn, string>> filterColumn,
            ContractSortColumn sortColumn, 
            Order order
        )
        {
            return JsonHelper.Get<Contract, ContractJsonForListedSearch, ContractFilterColumn, ContractSortColumn>(
                BaseUrl,
                fromResultIndex,
                toResultIndex,
                filterColumn,
                sortColumn,
                order,
                transformForListedSearch
            );
        }

        public async Task<IEnumerable<Contract>> GetAsync(
            int fromResultIndex,
            int toResultIndex,
            List<KeyValuePair<ContractFilterColumn, string>> filterColumn,
            ContractSortColumn sortColumn,
            Order order
        )
        {
            return await JsonHelper.GetAsync<Contract, ContractJsonForListedSearch, ContractFilterColumn, ContractSortColumn>(
                BaseUrl,
                fromResultIndex,
                toResultIndex,
                filterColumn,
                sortColumn,
                order,
                transformForListedSearch
            );
        }
    }
}
