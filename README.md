

### TODO
Now we have the most basic a Minimal Value Product ready. Next step is to create a good base which will speed up further development.

#### Backend
- [ ] Add test to backend 
- [ ] Cleanup GQL schema on backend (move to own folders)
- [ ] Remove code duplicates on the backend, create services and repositories to handle common functionality.
- [ ] Create a CD pipe that builds new releases, 
- [ ] Create a installer that can install from github releases https://github.com/inconshreveable/go-update

#### Frontend
- [ ] Add better linting
- [ ] Change to prettier?
- [ ] Add tests
- [ ] Look over dependencies
- [ ] Choose css/component lib

### Features
- [ ] Add "Mark as finnished/already seen" on episode context menu
- [ ] Add Sort support for arrays coming from GQL schema  
- [ ] Add download button/enable download to device somehow. (create a GRPC server for file transfers? Need support to queue up download, and prioritize)
- [ ] Remove Sonarr dependency (Read from out DB instead)