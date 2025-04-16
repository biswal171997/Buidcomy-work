function encryptData(data) {
    // Convert the integer data to a string
    var dataString = String(data);

    // Encrypt the data using CryptoJS
    var encryptedData = CryptoJS.AES.encrypt(JSON.stringify({ data: dataString }), 'secret_key').toString();

    return encryptedData;
}
function decryptData(encryptedData) {
    // Decrypt the encrypted data using CryptoJS
    var bytes = CryptoJS.AES.decrypt(encryptedData, 'secret_key');
    var decryptedData = JSON.parse(bytes.toString(CryptoJS.enc.Utf8));

    // Return the decrypted ID
    return decryptedData.data;
}
//encrypt sample encryptData(data.proposalid)
//decrypt sample decryptData(data.proposalid)