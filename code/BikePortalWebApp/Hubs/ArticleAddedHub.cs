using System;
using BikePortalWebApp.Models.BindingModel;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace BikePortalWebApp.Hubs
{
    [HubName("articleAddedMini")]
    public class ArticleAddedHub : Hub
    {
        private readonly ArticleAdded _articleAdded;

        public ArticleAddedHub() : this(ArticleAdded.Instance) { }

        public ArticleAddedHub(ArticleAdded articleAdded)
        {
            _articleAdded = articleAdded;
        }

        public void NotifyClients(ArticleBindingModel articleAdded)
        {
            Clients.All.broadcastMessage(articleAdded);
        }
    }

    public class ArticleAdded
    {
        private static readonly Lazy<ArticleAdded> _instance = new Lazy<ArticleAdded>(() => new ArticleAdded(
            GlobalHost.ConnectionManager.GetHubContext<ArticleAddedHub>().Clients));

        public static ArticleAdded Instance => _instance.Value;

        private ArticleAdded(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        }

        public IHubConnectionContext<dynamic> Clients { get; set; }

        public void BroadcastArticleAdded()
        {
            Clients.All.broadcastArticleAdded();
        }
    }
}