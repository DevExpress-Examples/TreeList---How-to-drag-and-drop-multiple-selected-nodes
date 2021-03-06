@Code
    ViewData("Title") = "Drag & Drop TreeList Nodes"
End Code

<script type="text/javascript">
    function onStartDragNode(s, e) {
        setTimeout(function () { CustomStartDragNode(s, e); }, 200);
    }

    function CustomStartDragNode(s, e) {
        var div = document.getElementById('treeListDiv').nextElementSibling;
        if (!div) return;
        var selectedKeys = s.GetVisibleSelectedNodeKeys();
        if (selectedKeys.indexOf(e.nodeKey) == -1 || selectedKeys.length == 0) return;
        table = div.childNodes[0];
        var row = table.rows[0];
        cloneRow = row.cloneNode(true);
        table.deleteRow(0);
        for (i = 0; i < selectedKeys.length; i++) {
            var row = cloneRow.cloneNode(true);
            var object = s.GetNodeHtmlElement(selectedKeys[i]).getElementsByClassName("customClass");
            for (var j = 0; j < object.length; j++) {
                row.cells[j].innerHTML = object[j].innerHTML;
            }
            table.appendChild(row);
        }
    }

    var nodeKeys = null;
    function onEndDragNode(s, e) {
        nodeKeys = s.GetVisibleSelectedNodeKeys();
    }

    function onBeginCallback(s, e) {
        if (nodeKeys != null) {
            e.customArgs["nodeKeys"] = nodeKeys;
            nodeKeys = null;
        }
    }
</script>

<div id="treeListDiv">
    @Html.Action("TreeListPartial")
</div>