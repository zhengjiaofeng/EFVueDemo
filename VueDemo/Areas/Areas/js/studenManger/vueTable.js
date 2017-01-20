$(function () {
    Vue.filter("jsonDateFormat", function (value) {
        try {
            var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
            var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
            var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
            var hours = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();
            var milliseconds = date.getMilliseconds();
            return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;

        } catch (ex) {
            return "";
        }
    });
    var vueTable = new Vue({
        el: "#VueTable",
        data: {
            contents: [],
            total: 0,//总页数
            currentPage: 0,//当前页数
            searchQuery:"",
        },
        methods: {
            loadStudenList: function (page, searchQuery) {
                var _stuentManger = this;
                var url = "/Areas/StudenManger/GetUserStudenList?currentPage=" + page;
                if (searchQuery != undefined && searchQuery != null && searchQuery != "")
                {
                    url += "&searchQuery=" + searchQuery;
                }
                $.ajax({
                    url: url,
                    type: "get",
                    dataType: "json",
                    async: false,
                    success: function (data) {
                        _stuentManger.$data.contents = [];
                        $.each(data.row, function (i, v) {
                            _stuentManger.$data.contents.push(v);
                        });
                        _stuentManger.$data.total = data.total;
                        _stuentManger.$data.currentPage = data.currentPage;
                    }
                });
            }
        },
        created: function () {
            this.loadStudenList(1);
            //this.loadPagintion();
        },
        filters: {
            genderToString: function (value) {
                return value == "0" ? "男" : value == "1" ? "女" : "";
            },
            is_graduationToString: function (value) {
                return value == false ? "否" : "是";
            }
        },
        watch: {
            searchQuery: function (value, oldValue) {
                this.loadStudenList(1, value);
            }
        }

    });

});