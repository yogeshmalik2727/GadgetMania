using System;

namespace GadgetMania.Models
{
    public class ErrorViewModel
    {
    /// </summary>
        public string RequestId { get; set; }
        
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
