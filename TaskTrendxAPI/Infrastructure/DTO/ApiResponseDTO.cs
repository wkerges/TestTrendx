using Newtonsoft.Json;
using System.ComponentModel;

namespace TaskTrendxAPI.Infrastructure.DTO
{
    [DisplayName("DefaultResponse")]
    public class ApiResponseDTO : ReturnBaseDTO
    {        
        [JsonIgnore]
        public bool WasException;

        [JsonIgnore]
        public int StatusCode;

        [JsonProperty(PropertyName = "resultObject", Order = int.MaxValue)]
        public object ResponseObject { get; set; }

        #region Methods
        public static ApiResponseDTO ConvertToApiResponseDTO(ReturnDTO ReturnDTO)
        {
            ApiResponseDTO apiResponseDTO = new ApiResponseDTO();            
            apiResponseDTO.IsSuccess = ReturnDTO.IsSuccess;
            apiResponseDTO.DeMessage = ReturnDTO.DeMessage;
            apiResponseDTO.ResponseObject = ReturnDTO.ResponseObject;
            apiResponseDTO.StatusCode = ReturnDTO.StatusCode;
            apiResponseDTO.WasException = (!string.IsNullOrEmpty(ReturnDTO.DeExceptionMessage));
            return apiResponseDTO;
        }
        #endregion
    }
}
