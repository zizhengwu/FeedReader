using System;
using System.Collections.Generic;
using System.Text;

namespace FeedReader
{
    public static class Css
    {
        public static string head =
@"
<!DOCTYPE html><html><head>
";
        public static string css =
@"
<style type=""text/css"">
div.feature {
    position: relative;
}

div.feature a {
    position: absolute;
    width: 100%;
    height: 100%;
    top: 0;
    left: 0;
    text-decoration: none; /* No underlines on the link */
    z-index: 10; /* Places the link above everything else in the div */
    background-color: #FFF; /* Fix to make div clickable in IE */
    opacity: 0; /* Fix to make div clickable in IE */
    filter: alpha(opacity=1); /* Fix to make div clickable in IE */
}
    
div.feature:active {
background-color: gray;
}
</style><body>
";

        public static string tail =
@"
</body></html>
";

        public static string title(string link, string time, string title, string author, string feed)
        {
            return string.Format(
@"
<div class=""feature"">
    <a href=""{0}""></a>
    <center>
        <h3>
        {1}
        <h3>
        <h1>{2}</h1>
        <h3>{3}</h3>
        <h3>{4}</h3>
    </center>
</div>
", link, time, title, author, feed);
        }
    }
}
