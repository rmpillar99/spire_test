Mac needs to install brew `/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`

Then run `brew install mono-libgdiplus` first, mono dependency for drawing (works with .net core)

Runs flawlessly in Linux

1. run `dotnet restore` to get the latest packages
2. run `dotnet run`
    - this will generate a PDF (TxtToPDF.pdf) from the text inside TestDocument.txt
    - will generate a text file (TextFromPDF.txt) of the text within sample.pdf