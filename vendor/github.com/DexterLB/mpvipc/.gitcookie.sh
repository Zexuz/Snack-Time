touch ~/.gitcookies
chmod 0600 ~/.gitcookies

git config --global http.cookiefile ~/.gitcookies

tr , \\t <<\__END__ >>~/.gitcookies
.googlesource.com,TRUE,/,TRUE,2147483647,o,git-hextwoa.gmail.com=1/ur7-27g70jeV0YY5lvoAZWBRCvu4KTxsgOFsv85repE
__END__
