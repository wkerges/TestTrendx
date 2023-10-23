namespace TaskTrendxAPI.Infrastructure.DTO
{
    public class ReturnDTO
    {
        #region Constructor
        public ReturnDTO() { }        
        #endregion

        #region Atributtes

        /// <summary>
        /// Status do retorno. Se for true, indica que tudo foi OK
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Descrição do retorno. Se success for false, retorna o motivo do erro
        /// </summary>
        public string DeMessage { get; set; }

        /// <summary>
        /// Status do retorno. Se for true, retorna o objeto esperado no endpoint
        /// </summary>
        public object ResponseObject;

        public int StatusCode;
        public string DeExceptionMessage;
        public string DeStackTrace;
        #endregion
    }
}
