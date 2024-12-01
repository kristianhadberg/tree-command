
# Tree Command



Program to print out a directory structure in a tree-like display. Like so:

```
├─childdir
│	├─childchildir
│	│	├─childchildchilddir
│	│	│	└─childchildchildchilddir
│	│	└─test.txt
│	├─.DS_Store
│	└─txt.txt
├─childdir2
│	├─test2.txt
│	└─test.txt
├─.DS_Store
└─test.txt

```
Currently the published version is set to compile and build to a macOS (arm64) executable.

### To run the program:
```bash
git clone https://github.com/kristianhadberg/tree-command.git
```

Change directory into the /tree-command directory and run:
```bash
./publish/Tree "path-name"
```
Path name being the directory you want to run the tree command on.
Eg.:
```bash
./publish/Tree .
```
If no directory is given the program defaults to the directory you're currently in.


