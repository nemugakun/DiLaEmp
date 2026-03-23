window.downloadFile = (filename, content) => {
    const blob = new Blob([content], { type: "application/json" });
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = url;
    a.download = filename;
    a.click();

    URL.revokeObjectURL(url);
};

window.scrollToElement = (elementId) => {
    console.log("1");
    console.log(elementId);
    const element = document.getElementById(elementId);
    console.log("2");
    console.log(element);
    if (element) {
        console.log("3");
        element.scrollIntoView({
            behavior: 'smooth',
            block: 'start',
            inline: 'nearest'
        });
        console.log("4");
    }
    console.log("5");
}