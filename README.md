Mac needs to install brew `/usr/bin/ruby -e "$(curl -fsSL https://raw.githubusercontent.com/Homebrew/install/master/install)"`

Then run `brew install mono-libgdiplus` first, mono dependency for drawing (works with .net core)

Runs flawlessly in Linux

1. run `dotnet restore` to get the latest packages
2. run `dotnet run`
    - this will generate a PDF (TxtToPDF.pdf) from the text inside TestDocument.txt
    - will generate a text file (TextFromPDF.txt) of the text within sample.pdf

Docker instructions:

`docker build . -t spire_test`
`docker run --name spire_test spire_test`
`docker commit spire_test test_image`
`docker run -it -v /Users/[your_username]/image_out/:/app/out --entrypoint=sh test_image`

Commands in shell:

`cp result.pdf TextFromPDF.txt TxtToPDf.pdf out`

Then check your mounted local volume (/Users/[your_username]/image_out/)

Unfortunately replace looks like garbage :(
