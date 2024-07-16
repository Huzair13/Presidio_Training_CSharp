const { BlobServiceClient } = require("@azure/storage-blob");

const createContainerButton = document.getElementById("create-container-button");
const deleteContainerButton = document.getElementById("delete-container-button");
const selectButton = document.getElementById("select-button");
const fileInput = document.getElementById("file-input");
const listButton = document.getElementById("list-button");
const deleteButton = document.getElementById("delete-button");
const status = document.getElementById("status");
const fileList = document.getElementById("file-list");

const reportStatus = message => {
    status.innerHTML += `${message}<br/>`;
    status.scrollTop = status.scrollHeight;
}


// Update <placeholder> with your Blob service SAS URL string
const blobSasUrl = "https://storagehuzair.blob.core.windows.net/?sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2024-07-17T19:17:17Z&st=2024-07-16T11:17:17Z&sip=106.197.121.118&spr=https&sig=7FUD9ehQe2bJzU3KG3REhIIA2tn2u3QBr4TsKINDNWI%3D";


// Create a new BlobServiceClient
const blobServiceClient = new BlobServiceClient(blobSasUrl);
// Create a unique name for the container by 
// appending the current time to the file name
const containerName = "container" + new Date().getTime();

// Get a container client from the BlobServiceClient
const containerClient = blobServiceClient.getContainerClient(containerName);

const createContainer = async () => {
    try {
        reportStatus(`Creating container "${containerName}"...`);
        await containerClient.create();
        reportStatus(`Done. URL:${containerClient.url}`);
    } catch (error) {
        reportStatus(error.message);
    }
};

const deleteContainer = async () => {
    try {
        reportStatus(`Deleting container "${containerName}"...`);
        await containerClient.delete();
        reportStatus(`Done.`);
    } catch (error) {
        reportStatus(error.message);
    }
};

createContainerButton.addEventListener("click", createContainer);
deleteContainerButton.addEventListener("click", deleteContainer);


const listFiles = async () => {
    fileList.size = 0;
    fileList.innerHTML = "";
    try {
        reportStatus("Retrieving file list...");
        const iter = containerClient.listBlobsFlat();
        for await (const blobItem of iter) {
            fileList.size += 1;
            fileList.innerHTML += `<option>${blobItem.name}</option>`;
        }
        if (fileList.size > 0) {
            reportStatus("Done.");
        } else {
            reportStatus("The container does not contain any files.");
        }
    } catch (error) {
        reportStatus(error.message);
    }
};

listButton.addEventListener("click", listFiles);

const uploadedImageContainer = document.getElementById("uploaded-image-container");

const uploadFiles = async () => {
  try {
    reportStatus("Uploading files...");
    const promises = [];
    for (const file of fileInput.files) {
        console.log("outside if")
      // Check if the uploaded file is an image
      if (!file.type.startsWith("image/")) {
        console.log("inside if")
        reportStatus(`${file.name} is not an image file. Skipping...`);
        continue;
      }
      const blockBlobClient = containerClient.getBlockBlobClient(file.name);
      promises.push(blockBlobClient.uploadBrowserData(file));
    }
    await Promise.all(promises);
    reportStatus("Done.");
    listFiles();
    // Clear existing images before displaying new ones
    uploadedImageContainer.innerHTML = "";
    displayUploadedImages();
  } catch (error) {
    reportStatus(error.message);
  }
};

const displayUploadedImages = async () => {
    try {
        reportStatus("Displaying uploaded images...");
        const iter = containerClient.listBlobsFlat();
        for await (const blobItem of iter) {
            if (blobItem.name &&
                (blobItem.name.toLowerCase().endsWith(".jpg") ||
                 blobItem.name.toLowerCase().endsWith(".jpeg") ||
                 blobItem.name.toLowerCase().endsWith(".png") ||
                 blobItem.name.toLowerCase().endsWith(".gif") ||
                 blobItem.name.toLowerCase().endsWith(".bmp") ||
                 blobItem.name.toLowerCase().endsWith(".tiff"))) {
                
                const blobUrl = `${containerClient.url}/${blobItem.name}`;
                
                const imageElement = document.createElement("img");
                imageElement.classList.add("image-preview");
                imageElement.src = blobUrl;
                uploadedImageContainer.appendChild(imageElement);
            } else {
                console.warn("Blob item is not an image:", blobItem.name);
            }
        }
        reportStatus("Done.");
    } catch (error) {
        reportStatus(error.message);
    }
};


  
selectButton.addEventListener("click", () => fileInput.click());
fileInput.addEventListener("change", uploadFiles);

const deleteFiles = async () => {
    try {
        if (fileList.selectedOptions.length > 0) {
            reportStatus("Deleting files...");
            for (const option of fileList.selectedOptions) {
                await containerClient.deleteBlob(option.text);
            }
            reportStatus("Done.");
            listFiles();
        } else {
            reportStatus("No files selected.");
        }
    } catch (error) {
        reportStatus(error.message);
    }
};

deleteButton.addEventListener("click", deleteFiles);
