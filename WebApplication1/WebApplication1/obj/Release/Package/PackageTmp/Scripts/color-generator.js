function get_region_attr(num, disease) {
    console.info(num, disease);
    if (!(parseInt(disease) in regionsColors) || !(parseInt(num) in regionsColors[parseInt(disease)]))
        return null;
    if (typeof regionsColors[parseInt(disease)][parseInt(num)] === 'undefined' || regionsColors[parseInt(disease)][parseInt(num)] === null)
        return null;
    return regionsColors[parseInt(disease)][parseInt(num)] ;
}