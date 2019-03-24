using System;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.AdminMenu.Services;
using OrchardCore.Navigation;
using System.Linq;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata.Models;
using Microsoft.Extensions.Logging;
using OrchardCore.Environment.Shell;
using System.Threading.Tasks;
using OrchardCore.Sitemaps;
using OrchardCore.Sitemaps.Models;
using System.Xml.Linq;

namespace OrchardCore.Contents.AdminNodes
{
    public class ContentTypesSitemapBuilder : ISitemapBuilder
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly ILogger<ContentTypesSitemapBuilder> _logger;
        private readonly string _contentItemlistUrl;

        public ContentTypesSitemapBuilder(
            IContentDefinitionManager contentDefinitionManager,
            ShellSettings shellSettings,
            ILogger<ContentTypesSitemapBuilder> logger)
        {
            _contentDefinitionManager = contentDefinitionManager;

            var tenantPrefix = ('/' + (shellSettings.RequestUrlPrefix ?? string.Empty)).TrimEnd('/');
            _contentItemlistUrl = tenantPrefix + "/Admin/Contents/ContentItems/";


            _logger = logger;
        }

        public string Name => typeof(ContentTypesAdminNode).Name;

        public Task<XDocument> BuildAsync(SitemapNode sitemapNode, SitemapBuilderContext sitemapContext)
        {
            //maybe. or would we be better of to allow entry points here to plug into the pipeline?
            sitemapContext.Namespaces.Add("http://www.sitemaps.org/schemas/sitemap/0.9");
            //how to we add to the namespace?
            XElement root = new XElement(xmlns + "urlset");
            //by moving these two bits up to the top, and providing namespace in the context, so we can add / alter it


            //this happens last, and should be in the sitemapbuilder
            XDocument document = new XDocument(root);


            var url = new XElement("url");

            throw new NotImplementedException();
        }


        //public async Task BuildNavigationAsync(MenuItem menuItem, NavigationBuilder builder, IEnumerable<IAdminNodeNavigationBuilder> treeNodeBuilders)
        //{
        //    var node = menuItem as ContentTypesAdminNode;

        //    if ((node == null) || (!node.Enabled))
        //    {
        //        return;
        //    }

        //    // Add ContentTypes specific children            
        //    var typesToShow = GetContentTypesToShow(node);
        //    foreach (var ctd in typesToShow)
        //    {
        //        builder.Add(new LocalizedString(ctd.DisplayName, ctd.DisplayName), cTypeMenu =>
        //        {
        //            cTypeMenu.Url(_contentItemlistUrl + ctd.Name);
        //            cTypeMenu.Priority(node.Priority);
        //            cTypeMenu.Position(node.Position);
        //            cTypeMenu.Permission(Permissions.EditOwnContent);

        //            GetIconClasses(ctd, node).ToList().ForEach(c => cTypeMenu.AddClass(c));
        //        });
        //    }


        //    // Add external children
        //    foreach (var childNode in node.Items)
        //    {
        //        try
        //        {
        //            var treeBuilder = treeNodeBuilders.Where(x => x.Name == childNode.GetType().Name).FirstOrDefault();
        //            await treeBuilder.BuildNavigationAsync(childNode, builder, treeNodeBuilders);
        //        }
        //        catch (Exception e)
        //        {
        //            _logger.LogError(e, "An exception occurred while building the '{MenuItem}' child Menu Item.", childNode.GetType().Name);
        //        }
        //    }

        //}

        //private IEnumerable<ContentTypeDefinition> GetContentTypesToShow(ContentTypesAdminNode node)
        //{

        //    var typesToShow = _contentDefinitionManager.ListTypeDefinitions()
        //        .Where(ctd => ctd.Settings.ToObject<ContentTypeSettings>().Listable);


        //    if (!node.ShowAll)
        //    {
        //        node.ContentTypes = node.ContentTypes ?? (new ContentTypeEntry[] { });

        //        typesToShow = typesToShow
        //            .Where(ctd => node.ContentTypes.ToList()
        //                            .Any(s => String.Equals(ctd.Name, s.ContentTypeId, StringComparison.OrdinalIgnoreCase)));

        //    }

        //    return typesToShow.OrderBy(t => t.DisplayName);
        //}

        //private List<string> GetIconClasses(ContentTypeDefinition contentType, ContentTypesAdminNode node)
        //{
        //    if (node.ShowAll)
        //    {
        //        return AddPrefixToClasses(node.IconClass);
        //    }
        //    else
        //    {
        //        var typeEntry = node.ContentTypes
        //                        .Where(x => String.Equals(x.ContentTypeId, contentType.Name, StringComparison.OrdinalIgnoreCase))
        //                        .FirstOrDefault();

        //        return AddPrefixToClasses(typeEntry.IconClass);

        //    }
        //}

        //private List<string> AddPrefixToClasses(string unprefixed)
        //{
        //    return unprefixed?.Split(' ')
        //        .ToList()
        //        .Select(c => "icon-class-" + c)
        //        .ToList<string>()
        //        ?? new List<string>();
        //}


    }

}
