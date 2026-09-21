using Microsoft.JSInterop;

namespace PROJECTNAME.Services;

public class CultureService
{
    private readonly IJSRuntime _js;

    public CultureService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetCultureAsync(string culture)
    {
        await _js.InvokeVoidAsync("blazorCulture.set", culture);
    }
}
