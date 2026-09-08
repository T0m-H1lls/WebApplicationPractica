using ClassLibraryWebAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathOperationController : ControllerBase
    {
        [HttpPost("Calc")]
        public MathResult Post([FromBody] MathSendData data)
        {
            MathResult result = new MathResult{Success=true};
            switch (data.Operator)
            {
                case '+':
                    result.Result = data.X + data.Y;
                    break;
                case '-':
                    result.Result = data.X - data.Y;
                    break;
                case '*':
                    result.Result = data.X * data.Y;
                    break;
                case '/':
                    if (data.Y == 0)
                    {
                        result.Success = false;
                        result.Message = "Деление на ноль";
                    }
                    else
                        result.Result = data.X / data.Y;
                    break;
                default:
                    result.Success = false;
                    result.Message = "Операция не поддерживается";
                    break;
                
            }
            return result;
        }
        
        
    }
}
