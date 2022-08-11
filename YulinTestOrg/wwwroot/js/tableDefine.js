var TableDefine = {
  order: [[0, "desc"]],
  //pagingType: "input",
  lengthMenu: [
    [10, 25, 50, 100, 500],
    [10, 25, 50, 100, 500],
  ],
  language: {
    processing: "處理中...",
    loadingRecords: "載入中...",
    lengthMenu: "顯示 _MENU_ 項結果",
    zeroRecords: "沒有符合的結果",
    info: "顯示第 _START_ 至 _END_ 項結果，共 _TOTAL_ 項",
    infoEmpty: "顯示第 0 至 0 項結果，共 0 項",
    infoFiltered: "(從 _MAX_ 項結果中過濾)",
    infoPostFix: "",
    search: "搜尋:",
    paginate: {
      first: "第一頁",
      previous: "上一頁",
      next: "下一頁",
      last: "最後一頁",
    },
    aria: {
      sortAscending: ": 升冪排列",
      sortDescending: ": 降冪排列",
    },
  },
  searching: false,
  processing: true,
  serverSide: true,
};

var SDTableObj = function () {
  var oTable;

  return {
    search: function (jqObj, tableOption) {
      if (typeof oTable === "undefined") {
        oTable = jqObj.DataTable($.extend(true, {}, TableDefine, tableOption));
      } else {
        oTable.clear().draw();
      }
    },
    searchAndCallBack: function (jqObj, tableOption, drawCallBack) {
      if (typeof oTable === "undefined") {
        //  處理部分頁面有客製化筆數
        if (typeof tableOption.lengthMenu !== "undefined") {
          TableDefine.lengthMenu = [];
        }

        oTable = jqObj.DataTable($.extend(true, {}, TableDefine, tableOption));

        oTable.on("draw", function () {
          drawCallBack();
        });
      } else {
        oTable.clear().draw();
      }
    },
  };
};
