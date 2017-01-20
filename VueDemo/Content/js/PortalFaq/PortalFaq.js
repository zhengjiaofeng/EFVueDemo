$(function () {
    var PortalFaq = new Vue({
        el: "#PortalFaq",
        data: {
            row: [],
            totalPage: 0,//页数
            currentPage: 1,
            alltotal: 4444,
            allCount: 0,
            questionCount: 0,
            discussionCount: 0,
        },
        methods: {
            loadCourseThreadList: function (listPage, lsitType) {
                var _PortalFaq = this;
                var url = "/PortalFaq/GetCourseThreadList";
                var pages = 1;
                if (listPage > 0) {
                    pages = listPage;
                }
                $.ajax({
                    url: url,
                    type: "get",
                    dataType: "json",
                    data: { "page": pages, "type": lsitType },
                    async: false,
                    success: function (data) {
                        if (data.isSuccess) {
                            _PortalFaq.row = data.row;
                            _PortalFaq.totalPage = data.totalPage;
                        }
                    }
                });
            },
            loadPagintion: function () {
                var _PortalFaq = this;
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
                        _PortalFaq.loadCourseThreadList(page);
                    }
                }
                $('#pagination').bootstrapPaginator(options);
            },
            loadEdotor: function () {
                var editor = UE.getEditor('editthread', {
                    toolbars: [[
                            'bold', 'italic', 'underline', 'forecolor', '|',
                            'link', 'unlink', 'anchor', '|',
                            'insertimage', 'cleardoc', '|'
                    ]], wordCount: false, elementPathEnabled: false,
                    scaleEnabled: false,
                    enableAutoSave: false, //关闭本地保存功能,
                    onready: function () {
                        this.on('showmessage', function (type, m) {
                            if (m['content'] == '本地保存成功') {
                                return true;
                            }
                        });
                    }//关闭本地保存功能
                })
            },
            open: function (type) {
                this.loadCourseThreadList(1, type);
                this.loadPagintion();
            },
            add: function () {
                var _PortalFaq = this;
                $("#content").val(encodeURI(UE.getEditor('editthread').getContent()));
                $.ajax({
                    url: "/PortalFaq/AddCourseThread",
                    type: "post",
                    jsonType: "json",
                    data: $("#fm").serialize(),
                    success: function (data) {
                        if (data.isSuccess) {
                            _PortalFaq.$children[0].loadCourseAllCount();
                        }
                    }
                });
            }
        },
        created: function () {
            this.loadCourseThreadList(this.totalPage, "all");
            this.loadPagintion();
            this.loadEdotor();
        },
        components: {
            templatehtml: {
                template: "#course-thread-class",
                data: function () {
                    return {
                        allCount: 0,
                        questionCount: 0,
                        discussionCount: 0
                    }
                },
                created: function () {
                    this.loadCourseAllCount();
                },
                methods: {
                    loadCourseAllCount: function () {
                        var _PortalFaqCon = this;
                        var url = "/PortalFaq/GetCourseAllCount";
                        $.ajax({
                            url: url,
                            type: "get",
                            dataType: "json",
                            async: false,
                            success: function (data) {
                                if (data.isSuccess) {
                                    _PortalFaqCon.allCount = data.allCount;
                                    _PortalFaqCon.questionCount = data.questionCount;
                                    _PortalFaqCon.discussionCount = data.discussionCount;
                                }
                            }
                        });
                    },
                }
            }
        }

    });
});