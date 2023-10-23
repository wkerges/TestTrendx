using TaskTrendxAPI.Infrastructure.DTO;
using TaskTrendxAPI.Infrastructure.Models;

namespace TaskTrendxAPI.Infrastructure.Services.Interface
{
    public interface ITaskService
    {
        Task<ApiResponseDTO> InsertTask(TaskModel taskModel);
        Task<ApiResponseDTO> GetTask();
        Task<ApiResponseDTO> UpdateTask(int id, TaskModel taskModel);
        Task<ApiResponseDTO> DeleteTask(int id);
    }
}
