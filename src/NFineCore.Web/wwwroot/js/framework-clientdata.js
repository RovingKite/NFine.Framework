var clients = [];
var tempData = "";
$(function () {
    clients = $.clientsInit();
})
$.clientsInit = function () {
    var dataJson = {
        dataItems: [],
        organize: [],
        role: [],
        position: [],
        user: [],
        authorizeMenu: [],
        authorizeButton: [],
        wxApp: [],
        wxMenu: []
    };
    var init = function () {
        $.ajax({
            url: "/ClientsData/GetClientsDataJson",
            type: "get",
            dataType: "json",
            async: false,
            success: function (data) {
                dataJson.dataItems = data.dataItems;
                dataJson.organize = data.organize;
                dataJson.role = data.role;
                dataJson.position = data.position;
                dataJson.authorizeMenu = eval(data.authorizeMenu);
                dataJson.authorizeButton = data.authorizeButton;
                dataJson.wxMenu = eval(data.wxMenu);
            }
        });
    }
    init();
    return dataJson;
}