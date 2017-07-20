using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NMUG.Models;
using Tweetinvi;
using Tweetinvi.Models;
using Microsoft.Extensions.Options;

namespace NMUG.Services
{
    public class TweetSender
    {

        private static IAuthenticatedUser _user;
        private TwitterAuthAPI twitterAuthAPI;
        private object @params;

        //  public TweetSender(IOptions<TwitterAuthAPI> OAuthParams)
        public TweetSender(TwitterAuthAPI OAuthParams)
        {
            twitterAuthAPI = OAuthParams; //.Value;

            var _auth = Auth.SetUserCredentials(twitterAuthAPI.ConsumerKey, twitterAuthAPI.ConsumerSecret, twitterAuthAPI.AccessToken, twitterAuthAPI.AccessTokenSecret);
           _user = Tweetinvi.User.GetAuthenticatedUser(_auth);
           
        }

        public TweetSender(TwitterAuthAPI twitterAuthAPI, object @params)
        {
            this.twitterAuthAPI = twitterAuthAPI;
            this.@params = @params;
        }

        public IEnumerable<ITweet> GetTimeline(int numberOfTweets, IAuthenticatedUser _user)
        {

            //return Timeline.GetUserTimeline(_user, numberOfTweets);
            return _user.GetUserTimeline(numberOfTweets);
        }

        public void PostTwitter(string tweet)
        {
            Tweet.PublishTweet(tweet);
        }
    }
}
