function stage1_data(json) {
    var disease = $("#MainContent_DiseaseDropDownList").val();
    var region = $("#MainContent_RegionDropDownList").val();
    var stage = [0, 0, 0];
    if (!(parseInt(disease) in json))
        return stage;
    console.info("not here");
    if (!(parseInt(region) in json[parseInt(disease)]))
        return stage;
    console.info("not here");

    if (!(1 in json[parseInt(disease)][parseInt(region)]))
        return stage;
    console.info("not here");
    if (1 in json[parseInt(disease)][parseInt(region)][1])
        stage[0] = json[parseInt(disease)][parseInt(region)][1][1];
    if (2 in json[parseInt(disease)][parseInt(region)][1])
        stage[1] = json[parseInt(disease)][parseInt(region)][1][2];
    if (3 in json[parseInt(disease)][parseInt(region)][1])
        stage[2] = json[parseInt(disease)][parseInt(region)][1][3];
    return stage;
}
function stage2_data(json) {
    var disease = $("#MainContent_DiseaseDropDownList").val();
    var region = $("#MainContent_RegionDropDownList").val();
    var stage = [0, 0, 0];
    if (!(parseInt(disease) in json))
        return stage;
    if (!(parseInt(region) in json[parseInt(disease)])) 
        return stage;
    if (!(2 in json[parseInt(disease)][parseInt(region)]))
        return stage;
    if (1 in json[parseInt(disease)][parseInt(region)][2])
        stage[0] = json[parseInt(disease)][parseInt(region)][2][1];
    if (2 in json[parseInt(disease)][parseInt(region)][2])
        stage[1] = json[parseInt(disease)][parseInt(region)][2][2];
    if (3 in json[parseInt(disease)][parseInt(region)][2])
        stage[2] = json[parseInt(disease)][parseInt(region)][2][3];
    return stage;
}

function stage3_data(json) {
    var disease = $("#MainContent_DiseaseDropDownList").val();
    var region = $("#MainContent_RegionDropDownList").val();
    var stage = [0, 0, 0];
    if (!(parseInt(disease) in json))
        return stage;
    if (!(parseInt(region) in json[parseInt(disease)]))
        return stage;
    if (!(3 in json[parseInt(disease)][parseInt(region)]))
        return stage;
    if (1 in json[parseInt(disease)][parseInt(region)][3])
        stage[0] = json[parseInt(disease)][parseInt(region)][3][1];
    if (2 in json[parseInt(disease)][parseInt(region)][3])
        stage[1] = json[parseInt(disease)][parseInt(region)][3][2];
    if (3 in json[parseInt(disease)][parseInt(region)][3])
        stage[2] = json[parseInt(disease)][parseInt(region)][3][3];
    return stage;
}