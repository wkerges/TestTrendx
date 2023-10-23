using Newtonsoft.Json;

namespace TaskTrendxAPI.Infrastructure.DTO
{
    public class ReturnBaseDTO
    {
        #region Atributtes
        /// <summary>
        /// Status do retorno. Se for true, indica que tudo foi OK
        /// </summary>
        [JsonProperty(Order = 1)]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Descrição do retorno. Se success for false, retorna o motivo do erro
        /// </summary>
        [JsonProperty(Order = 2)]
        public string DeMessage { get; set; }
        #endregion
    }
}
