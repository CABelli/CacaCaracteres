using CacaCaracteres.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web;

namespace CacaCaracteres.FiltrosMensagem;

public class MessageOrExceptionFilter : IExceptionFilter
{
    private readonly ILogger<MessageOrExceptionFilter> _logger;

    public MessageOrExceptionFilter(IServiceProvider serviceProvider)
    {
        _logger = serviceProvider.GetRequiredService<ILogger<MessageOrExceptionFilter>>();
    }

    public void OnException(ExceptionContext context) 
    {
        if (context.Exception is LivroTextoException) 
        {
            OutPutLogger(context);
            TratarLivroTextoException(context);
        }
        else
        {
            _logger.LogError(context.Exception.Message);
            ThrowUnKnowError(context);
        }
    }

    private void OutPutLogger(ExceptionContext context)
    {
        if (context.Exception is ErrorsNotFoundException)
        {
            var notFoundErros = context.Exception as ErrorsNotFoundException;
            notFoundErros?.MensagensDeErro.ForEach(msg => _logger.LogInformation(" Aqui --- " + msg));
        }
    }

    private static void TratarLivroTextoException(ExceptionContext context)
    {
        if (context.Exception is ErrorsNotFoundException)
        {
            TratarErrorsNotFoundException(context);
        }
    }

    private static void TratarErrorsNotFoundException(ExceptionContext context)
    {
        var erros = context.Exception as ErrorsNotFoundException;
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
        context.HttpContext.Response.Headers.Add("Reason", HttpUtility.HtmlEncode(erros.MensagensDeErro.FirstOrDefault()));
        context.Result = new ObjectResult("");
    }

    private static void ThrowUnKnowError (ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(context.Exception.Message);
    }
}
