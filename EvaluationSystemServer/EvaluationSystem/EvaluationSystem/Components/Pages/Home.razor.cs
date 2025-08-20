using EvaluationSystemServer;
using Web;

namespace EvaluationSystem.Components.Pages;
public partial class Home
{
    private UserResponseModel? mUser;

    private string? mErrorMessage;

    public async void TestClient()
    {
        var client = new EvaluationSystemClient();

        var result = await client.GetUserAsync(1);


        if (!result.IsSuccessful)
        {
            mErrorMessage = result.ErrorMessage;
        }
        
        mUser = result.Result;
    }
}
