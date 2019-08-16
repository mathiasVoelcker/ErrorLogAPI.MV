# ErrorLogAPI.MV

This Package is design to help logging errors in a .NET API.


Controller Example:
```
public class DefaultController: CoreBaseController
{
    public DefaultController(IErrorLogger errorLogger): base(errorLogger) { }

    [HttpGet]
    public HttpResponseMessage Get() {
        return ExecFunc(() => Request.CreateResponse(HttpStatusCode.OK, [your logic here]))
    }
}
```

For the errorLogger to work, a dependency injection has to be made
```
    container.Register<IErrorLogger>(factory => new ErrorLogger([your log file path]));
```