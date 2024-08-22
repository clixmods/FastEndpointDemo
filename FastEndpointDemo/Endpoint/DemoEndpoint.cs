using FastEndpointDemo.Request;
using FastEndpointDemo.Response;
using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace FastEndpointDemo.Endpoint;

public class DemoEndpoint : Endpoint<DemoRequest,DemoResponse>
{
    private const string ImageUrl = "Resources/secret_image.gif";

    public override void Configure()
    {
        Get("demo/{giveMeImageURL}");
        
        // Require to bypass the authentication
        AllowAnonymous();
    }

    public override async Task HandleAsync(DemoRequest req, CancellationToken ct)
    {
        if (req.GiveMeImageURL)
        {
            FileInfo fileInfo = new FileInfo(ImageUrl);
            
            await SendFileAsync(fileInfo, cancellation: ct);
            
            await SendAsync(new DemoResponse()
                {
                    ACoolMessage = "Here is the image URL"
                }, 
                StatusCodes.Status200OK,
                ct);
        }
        else
        {
            await SendAsync(new DemoResponse()
                {
                    ACoolMessage = "No image sadly is the image URL"
                }, 
                StatusCodes.Status200OK,
                ct);
            
        }
        
    }
}