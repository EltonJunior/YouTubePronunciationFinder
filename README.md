# YouTubePronunciationFinder


## Obtain a YouTube Data API Key

1. **Create a Project on Google Cloud**:
   - Go to the [Google Cloud Console](https://console.cloud.google.com/).
   - Create a new project.

2. **Enable the YouTube Data API**:
   - In your project, navigate to the **Library** section.
   - Search for "YouTube Data API v3" and click on it.
   - Click the **Enable** button.

3. **Create API Credentials**:
   - Go to the **Credentials** section in the Google Cloud Console.
   - Click on **Create Credentials** and choose **API Key**.
   - Copy the generated API key and save it securely, preferably in a file named `apiKey.txt` in your project directory.


### Key Features

- **Loading the API Key**: The API key is loaded from a text file, with exception handling for missing or empty keys.
- **Making Requests**: The application constructs a request URL for the YouTube Data API and handles potential errors such as network issues.
- **Searching Videos**: It searches for videos with the specified keyword in their titles and can later check for the keyword in video captions.
