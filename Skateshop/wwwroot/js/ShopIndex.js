
$().ready(() => {
    $.ajax({
        url: "shop/GetAllItems/",
        method: "GET",
        success: dataFromServer => {
            let items = ""

            for (let i = 0; i < dataFromServer.length; i++) {
                items += getItemHTML(dataFromServer[i])
            }

            $("#shopGrid").html(items)
        },
        error: () => {

        }
    })
})

function getNameForItemTypeInt(itemTypeInt) {
    switch (itemTypeInt) {
        case 0:
            return "Deck";
        case 1:
            return "Truck";
        case 2:
            return "Wheels";
        case 3:
            return "Bearings";
        default:
            return "notSpecified";
    }
}

function getItemHTML(item) {
    let imagepath = "/img/shop/"
    let altpath = ""
    if (item.image == null || item.image == "") {
        imagepath += "missingImage.png"
    }
    else {
        imagepath += item.image
        if (item.itemType == 0) {
            altpath = imagepath + "b.jpg"
        }
        imagepath += ".jpg"
    }

    return `
<div class="griditem rounded-sm">
    <div class="itemTitle itemText">
        ${item.manufacturer}
        ${getNameForItemTypeInt(item.itemType)}
    </div>
    <div>
        <img id="shopItem-${item.id}" src="${imagepath}" class="itemImg" onclick="flipBoard(${item.id}, '${getNameForItemTypeInt(item.itemType)}', '${imagepath}', '${altpath}')"/>
    </div>
    <div class="itemPrice itemText">
        ${item.price} EUR
    </div>
    <div class="itemText">
        ${item.description} ${item.size}
    </div>
</div>`
}
