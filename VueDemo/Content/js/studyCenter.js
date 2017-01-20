$(function () {
    var studyCenty = new Vue({
        el: "#studyCenter",
        data: {
            row: {},
            totalPage: 0,
            currentPage:1
        },
        methods: {
            loadStudyCenterList: function (page) {
                var _studyCenter = this;
                var url = "/Home/GetStudyCenter";
                if (page == undefined || page == null || page == "") {
                    page = 1;
                } else {
                    url += "?page=" + page;
                }
                $.ajax({
                    url: url,
                    type: "get",
                    dataType: "json",
                    data: { "page": page },
                    async:false,
                    success: function (data) {
                        if (!data.isSuccess) {
                            alert("出错了！")
                        } else {
                            _studyCenter.totalPage = data.totalPage;
                            _studyCenter.row = data.row;
                        }
                    }
                });
            },
            loadPagintion: function () {
                var _studyCenter = this;
                var current = this.currentPage == 0 ? 1 : this.currentPage;
                var totalPage = this.totalPage;
                var options = {
                    // bootstrapMajorVersion: 2,
                    currentPage: current, //当前页数
                    totalPages: totalPage, //总页数
                    numberOfPages: 4,
                    itemTexts: function (type, page, current) {
                        switch (type) {
                            case "first":
                                return "首页";
                            case "prev":
                                return "上一页";
                            case "next":
                                return "下一页";
                            case "last":
                                return "末页";
                            case "page":
                                return page;
                        }
                    }, tooltipTitles: function (type, page, current) {
                        switch (type) {
                            case "first":
                                return "首页";
                            case "prev":
                                return "上一页";
                            case "next":
                                return "下一页";
                            case "last":
                                return "末页";
                            case "page":
                                return (page === current) ? "当前第" + page + "页" : "第" + page + "页";
                        }
                    }, onPageClicked: function (event, originalEvent, type, page) {
                        // location.href = "/StudenManger/GetUserStudenList?&currentPage=" + page;
                        _studyCenter.loadStudyCenterList(page);
                    }
                }
                $('#pagination').bootstrapPaginator(options);
            },

        },
        created: function () {
            this.loadStudyCenterList();
            this.loadPagintion();
        },
        filters: {
            IntroductionFilter: function (value) {
                if (value != null && value != undefined) {
                    if (value.length > 15) {
                        var data = value.substring(0, 15) + "...";
                        return data;
                    } else {
                        return value;
                    }

                } else {
                    return "暂无简介";
                }
            },
            PlatNameFilter: function (value) {
                if (value != null && value != undefined) {
                    if (value.length > 12) {
                        var data = value.substring(0, 12) + "...";
                        return data;
                    } else {
                        return value;
                    }

                } else {
                    return "";
                }
            }
        }
    }
    );
});