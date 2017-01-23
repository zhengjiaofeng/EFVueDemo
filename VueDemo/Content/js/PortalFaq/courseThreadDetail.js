$(function () {
    var courseThreadDetail = new Vue({
        el: "#courseThreadDetail",
        data:{
            
        },
        components: {
            templatedetaillist: {
                template: "#detailList",
                data: function () {
                    return {
                        detailList: {},
                        courseThread:{},
                        treadId: treadId,
                        idc:""
                    }
                },
                props: ["idc"],
                methods: {
                    loadDetailListFun: function () {
                        var _courseThreadDetail = this;
                        $.ajax({
                            url: "/PortalFaq/GetCourseThreadDetailList",
                            Type: "get",
                            dataType: "json",
                            data: { threadId: _courseThreadDetail.treadId },
                            async:false,
                            success: function (data) {
                                if (data.isSuccess) {
                                    _courseThreadDetail.detailList = data.detailList;
                                    _courseThreadDetail.courseThread = data.courseThread
                                } else {
                                    alert("错误");
                                }
                            }
                        });
                    }
                },
                created: function () {
                    this.loadDetailListFun();
                    this.idc = "222";
                }
            }
        }
    })
});