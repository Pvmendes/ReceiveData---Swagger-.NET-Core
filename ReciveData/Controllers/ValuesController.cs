using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logs.Interface;
using Logs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ReciveData.Domain.Intefaces.Service;
using ReciveData.Domain.Models;

namespace ReciveData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;

        private readonly IReceiveDataBussinessLogs reciveDataBussinessLogs;
        private readonly IReceiveDataService reciveDataService;

        public ValuesController(
            IConfiguration config,
            IReceiveDataBussinessLogs reciveDataBussinessLogs,
            IReceiveDataService reciveDataService)
        {
            configuration = config;
            this.reciveDataBussinessLogs = reciveDataBussinessLogs;
            this.reciveDataService = reciveDataService;
        }

        // GET api/values/5
        /// <summary>
        /// Busca informações.
        /// </summary>
        /// <param name="id">Id de busca</param>
        /// <returns>Retorna o objeto que procura.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiveDataLogEntitie>> SetLog(int id)
        {
            string conString = configuration
                .GetConnectionString("DefaultNoSQLConnection");

            var logModel = new ReceiveDataLogEntitie()
            {
                IdClient = id,
                Json = id.ToString(),
                Data = DateTime.Now,
                Exception = new Exception("Teste").ToString(),
                MethodName = "SetLog"
            };

            await reciveDataBussinessLogs.Save(logModel);

            return logModel;
        }

        /// <summary>
        /// Save all information user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns></returns>
        [Route("SaveUser")]
        [HttpPost]
        public async Task<ActionResult<string>> SaveUser(User user)
        {
            try
            {
                return JsonConvert.SerializeObject(await reciveDataService.SaveUser(user));
            }
            catch (Exception ex)
            {
                var logModel = new ReceiveDataLogEntitie()
                {
                    IdClient = user.Id,
                    Json = JsonConvert.SerializeObject(user),
                    Data = DateTime.Now,
                    Exception = ex.ToString(),
                    MethodName = "SaveUser"
                };

                await reciveDataBussinessLogs.Save(logModel);
                throw ex;
            }
        }

        /// <summary>
        /// Save all Itens from user
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("SaveItem")]
        [HttpPost]
        public async Task<ActionResult<string>> SaveItem(IEnumerable<Item> itensList)
        {
            try
            {
                await reciveDataService.SaveItem(itensList);
            }
            catch (Exception ex)
            {
                var logModel = new ReceiveDataLogEntitie()
                {
                    IdClient = itensList.FirstOrDefault().Id,
                    Json = JsonConvert.SerializeObject(itensList),
                    Data = DateTime.Now,
                    Exception = ex.ToString(),
                    MethodName = "SaveItem"
                };

                await reciveDataBussinessLogs.Save(logModel);
                throw ex;
            }
            return "done !";
        }
    }
}
