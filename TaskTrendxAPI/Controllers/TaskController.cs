using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskTrendxAPI.Infrastructure.DTO;
using TaskTrendxAPI.Infrastructure.Models;
using TaskTrendxAPI.Infrastructure.Services.Interface;

namespace TaskTrendxAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Insere a tarefa na base
        /// </summary>
        /// <param name="taskModel">Body com a tarefa a ser inserida.</param>
        /// <returns></returns>
        /// <response code="200">Processou os dados com sucesso.</response>
        /// <response code="400">Erro ao inserir a tarefa na base.</response>
        /// <response code="500">Erro no processamento da api.</response>
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ApiResponseDTO>> Post([FromBody] TaskModel taskModel)
        {
            ApiResponseDTO apiResponseDTO = await _taskService.InsertTask(taskModel);
            var response = new ObjectResult(apiResponseDTO);
            response.StatusCode = apiResponseDTO.StatusCode;

            return response;
        }

        /// <summary>
        /// Listar as tarefas
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Consulta executada com sucesso.</response>
        /// <response code="400">Erro ao consutar os dados.</response>
        /// <response code="404">Não foi encontrado tarefas.</response>
        /// <response code="500">Erro no processamento da api.</response>
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<ApiResponseDTO>> Get()
        {
            ApiResponseDTO apiResponseDTO = await _taskService.GetTask();
            var response = new ObjectResult(apiResponseDTO);
            response.StatusCode = apiResponseDTO.StatusCode;

            return response;
        }

        /// <summary>
        /// Atualiza a tarefa buscando pelo id
        /// </summary>
        /// <param name="id">Id da tarefa.</param>
        /// <param name="taskModel">Body com os dados da tarefa.</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TaskModel taskModel)
        {
            ApiResponseDTO apiResponseDTO = await _taskService.UpdateTask(id, taskModel);
            var response = new ObjectResult(apiResponseDTO);
            response.StatusCode = apiResponseDTO.StatusCode;

            return response;
        }

        /// <summary>
        /// Deleta uma tarefa pelo seu id
        /// </summary>
        /// <param name="id">Id da tarefa.</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            ApiResponseDTO apiResponseDTO = await _taskService.DeleteTask(id);
            var response = new ObjectResult(apiResponseDTO);
            response.StatusCode = apiResponseDTO.StatusCode;

            return response;
        }
    }
}
