using RestSharp;
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class UserPostsSteps
{
    private RestClient _client;
    private RestResponse _response;

    [Given(@"I have a valid API endpoint")]
    public void GivenIHaveAValidApiEndpoint()
    {
        _client = new RestClient("https://jsonplaceholder.typicode.com");
    }

    [When(@"I send a GET request to ""(.*)""")]
    public void WhenISendAGETRequestTo(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        _response = _client.Execute(request);
    }

    [Then(@"the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
    }

    [Then(@"the response should contain a list of posts")]
    public void ThenTheResponseShouldContainAListOfPosts()
    {
        Assert.IsTrue(_response.Content.Contains("title"));
    }

    [Given(@"the post ID is (.*)")]
    public void GivenThePostIDIs(int postId)
    {
       
    }

    [Then(@"the response should contain the post with ID (.*)")]
    public void ThenTheResponseShouldContainThePostWithID(int postId)
    {
        Assert.IsTrue(_response.Content.Contains($"\"id\": {postId}"));
    }
}
