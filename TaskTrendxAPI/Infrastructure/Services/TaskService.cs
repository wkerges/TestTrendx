using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System.Diagnostics;
using TaskTrendxAPI.Context;
using TaskTrendxAPI.Infrastructure.DTO;
using TaskTrendxAPI.Infrastructure.Models;
using TaskTrendxAPI.Infrastructure.Repositories;
using TaskTrendxAPI.Infrastructure.Services.Interface;

namespace TaskTrendxAPI.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ILogger<TaskService> _logger;
        private readonly TaskDbContext _dbContext;

        public TaskService(ILogger<TaskService> logger, TaskDbContext taskDbContext)
        {
            _logger = logger;
            _dbContext = taskDbContext;
        }

        public async Task<ApiResponseDTO> InsertTask(TaskModel taskModel)
        {
            string nmMethod = "InsertTask";
            ReturnDTO returnDTO = new ReturnDTO();

            try
            {
                _logger.LogInformation($"{nmMethod} => Start");
                _logger.LogInformation($"{nmMethod} => BodyReceived: {JsonConvert.SerializeObject(taskModel)}");

                TaskTb model = new TaskTb()
                {
                    Title = taskModel.Title,
                    Description = taskModel.Description,
                    Completed = taskModel.Completed
                };

                EntityEntry<TaskTb> save = await _dbContext.TaskTbs.AddAsync(model);
                int result = await _dbContext.SaveChangesAsync();

                if (result <= 0)
                {
                    returnDTO.IsSuccess = false;
                    returnDTO.DeMessage = "Falha ao inserir os dados na base.";
                    returnDTO.StatusCode = StatusCodes.Status400BadRequest;
                    returnDTO.ResponseObject = null;

                    _logger.LogInformation($"{nmMethod} => ReturnDTO: {JsonConvert.SerializeObject(returnDTO)}");
                    _logger.LogInformation($"{nmMethod} => End");

                    return ApiResponseDTO.ConvertToApiResponseDTO(returnDTO);
                }

                returnDTO.IsSuccess = true;
                returnDTO.DeMessage = "Dados inseridos com sucesso";
                returnDTO.StatusCode = StatusCodes.Status200OK;
                returnDTO.ResponseObject = model;
            }
            catch (Exception ex)
            {
                returnDTO.IsSuccess = false;
                returnDTO.DeExceptionMessage = ex.Message;
                returnDTO.DeStackTrace = ex.StackTrace;
                returnDTO.ResponseObject = null;
                returnDTO.DeMessage = "Ocorreu um erro ao efetuar o processamento da api";
                returnDTO.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError($"{nmMethod} => Exception: {ex}");
            }

            _logger.LogInformation($"{nmMethod} => ReturnDTO: {JsonConvert.SerializeObject(returnDTO)}");
            _logger.LogInformation($"{nmMethod} => End");

            return ApiResponseDTO.ConvertToApiResponseDTO(returnDTO);
        }

        public async Task<ApiResponseDTO> GetTask()
        {
            string nmMethod = "GetTask";
            ReturnDTO returnDTO = new ReturnDTO();

            try
            {
                _logger.LogInformation($"{nmMethod} => Start");

                List<TaskTb> taskList = await _dbContext.TaskTbs.ToListAsync();

                if (taskList == null)
                {
                    returnDTO.DeMessage = "As tarefas retornaram nulas.";
                    returnDTO.IsSuccess = false;
                    returnDTO.ResponseObject = null;
                    returnDTO.StatusCode = StatusCodes.Status400BadRequest;
                }
                else if (!taskList.Any())
                {
                    returnDTO.DeMessage = "Lista de tarefas é vazia.";
                    returnDTO.IsSuccess = false;
                    returnDTO.ResponseObject = taskList;
                    returnDTO.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    returnDTO.IsSuccess = true;
                    returnDTO.DeMessage = "Processo executado com sucesso";
                    returnDTO.StatusCode = StatusCodes.Status200OK;
                    returnDTO.ResponseObject = taskList;
                }
            }
            catch (Exception ex)
            {
                returnDTO.IsSuccess = false;
                returnDTO.DeExceptionMessage = ex.Message;
                returnDTO.DeStackTrace = ex.StackTrace;
                returnDTO.ResponseObject = null;
                returnDTO.DeMessage = "Ocorreu um erro ao efetuar o processamento da api";
                returnDTO.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError($"{nmMethod} => Exception: {ex}");
            }

            _logger.LogInformation($"{nmMethod} => ReturnDTO: {JsonConvert.SerializeObject(returnDTO)}");
            _logger.LogInformation($"{nmMethod} => End");

            return ApiResponseDTO.ConvertToApiResponseDTO(returnDTO);
        }

        public async Task<ApiResponseDTO> UpdateTask(int id, TaskModel taskModel)
        {
            string nmMethod = "UpdateTask";
            ReturnDTO returnDTO = new ReturnDTO();

            try
            {
                var task = await _dbContext.TaskTbs.FirstOrDefaultAsync(t => t.Id == id);

                if (task == null)
                {
                    returnDTO.DeMessage = "Tarefa não encontrada.";
                    returnDTO.IsSuccess = false;
                    returnDTO.ResponseObject = task;
                    returnDTO.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    if (task.Title != taskModel.Title)
                        task.Title = taskModel.Title;

                    if (task.Description != taskModel.Description)
                        task.Description = taskModel.Description;

                    if (task.Completed != taskModel.Completed)
                        task.Completed = taskModel.Completed;

                    if (await _dbContext.SaveChangesAsync() <= 0)
                    {
                        returnDTO.DeMessage = "Falha ao atualizar a tarefa.";
                        returnDTO.IsSuccess = false;
                        returnDTO.ResponseObject = null;
                        returnDTO.StatusCode = StatusCodes.Status400BadRequest;
                    }
                    else
                    {
                        returnDTO.DeMessage = "Tarefa atualizada com sucesso.";
                        returnDTO.IsSuccess = true;
                        returnDTO.ResponseObject = taskModel;
                        returnDTO.StatusCode = StatusCodes.Status200OK;
                    }
                }
            }
            catch (Exception ex)
            {
                returnDTO.IsSuccess = false;
                returnDTO.DeExceptionMessage = ex.Message;
                returnDTO.DeStackTrace = ex.StackTrace;
                returnDTO.ResponseObject = null;
                returnDTO.DeMessage = "Ocorreu um erro ao efetuar o processamento da api";
                returnDTO.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError($"{nmMethod} => Exception: {ex}");
            }

            _logger.LogInformation($"{nmMethod} => ReturnDTO: {JsonConvert.SerializeObject(returnDTO)}");
            _logger.LogInformation($"{nmMethod} => End");

            return ApiResponseDTO.ConvertToApiResponseDTO(returnDTO);
        }

        public async Task<ApiResponseDTO> DeleteTask(int id)
        {
            string nmMethod = "DeleteTask";
            ReturnDTO returnDTO = new ReturnDTO();

            try
            {
                TaskTb? task = await _dbContext.TaskTbs.FirstOrDefaultAsync(t => t.Id == id);

                if (task == null)
                {
                    returnDTO.DeMessage = "Tarefa não encontrada.";
                    returnDTO.IsSuccess = false;
                    returnDTO.ResponseObject = task;
                    returnDTO.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    EntityEntry<TaskTb> remove = _dbContext.Remove(task);

                    _logger.LogInformation($"{nmMethod} => Status Exclused: {remove.State.ToString()}");

                    if (remove.State == EntityState.Deleted)
                    {
                        if (await _dbContext.SaveChangesAsync() >= 0)
                        {
                            returnDTO.DeMessage = "Tarefa excluída com sucesso.";
                            returnDTO.IsSuccess = true;
                            returnDTO.ResponseObject = task;
                            returnDTO.StatusCode = StatusCodes.Status200OK;                            
                        }
                        else
                        {
                            returnDTO.DeMessage = "Erro ao salvar a exclusão.";
                            returnDTO.IsSuccess = false;
                            returnDTO.ResponseObject = task;
                            returnDTO.StatusCode = StatusCodes.Status400BadRequest;
                        }
                    }
                    else
                    {
                        returnDTO.DeMessage = "Não foi possível efetuar a exclusão.";
                        returnDTO.IsSuccess = false;
                        returnDTO.ResponseObject = $"Status da exclusão: {remove.State}";
                        returnDTO.StatusCode = StatusCodes.Status400BadRequest;
                    }                    
                }
            }
            catch (Exception ex)
            {
                returnDTO.IsSuccess = false;
                returnDTO.DeExceptionMessage = ex.Message;
                returnDTO.DeStackTrace = ex.StackTrace;
                returnDTO.ResponseObject = null;
                returnDTO.DeMessage = "Ocorreu um erro ao efetuar o processamento da api";
                returnDTO.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError($"{nmMethod} => Exception: {ex}");
            }

            _logger.LogInformation($"{nmMethod} => ReturnDTO: {JsonConvert.SerializeObject(returnDTO)}");
            _logger.LogInformation($"{nmMethod} => End");

            return ApiResponseDTO.ConvertToApiResponseDTO(returnDTO);
        }
    }
}
