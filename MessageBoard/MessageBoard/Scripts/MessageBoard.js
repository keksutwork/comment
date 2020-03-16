$(document).ready(function () {
    console.log(HostName);
    MessageBoardFunctions.GetAndAppendArticles();
});
var MessageBoardFunctions = {};
MessageBoardFunctions.articlePerPage = 10;
MessageBoardFunctions.GetAndAppendArticles = function (articlePerPage) {
    $.getJSON(`http://${HostName}/api/ArticleData/${articlePerPage}`
        , function (data) {
            var target = $("#AppendTarget");
            target.children().remove();
            data.forEach(function (data) {
                target.append(MessageBoardFunctions.CreateRowHtml(data));
            })
        }
    )
};
MessageBoardFunctions.CreateRowHtml = function (data) {
    return `<tr><td>${data.ArticleId}</td> <td>${data.PostBy}</td> <td>${data.Title}</td> <td>${data.PostDate}</td></tr>`;
}