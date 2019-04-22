<template>
  <div class="container">
    <h3>Snack-Time Settings</h3>
    <setting-card>
      <span class="card-title">Local System</span>
      <div class="row">
        <div class="col s6">
          <input
            id="fileDir"
            type="text"
            placeholder="D:\Snack-Time\"
            v-model="storagePath"
          />
          <label for="fileDir">Snack-Time storage</label>
        </div>
        <div class="col s6">
          <input
            id="fileDirTemp"
            type="text"
            placeholder="D:\Snack-Time\Temp"
            v-model="storagePathTemp"
          />
          <label for="fileDirTemp">Snack-Time Temp storage</label>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <input
            id="mpv-location"
            type="text"
            placeholder="C:\Program Files (x86)\SVP 4\mpv64\mpv.exe"
            v-model="mpvPath"
          />
          <label for="mpv-location">Mpv location</label>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <label>
            <input
              type="text"
              placeholder="C:\Program Files (x86)\SVP 4\SVPManager.exe"
              v-model="svpPath"
            />
            SVP location
          </label>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <button class="btn right" @click="save()">Save</button>
        </div>
      </div>
    </setting-card>
    <setting-card>
      <span class="card-title">Database</span>
      <div class="row">
        <div class="col s12">
          <p>Last synced [DATE]</p>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <label>
            <input type="text" placeholder="ASd" v-model="mediaLocation" />
            Snack-Time Media server address
          </label>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <button class="btn">Sync now!</button>
        </div>
      </div>
    </setting-card>
    <setting-card>
      <span class="card-title">Offline</span>
      <div class="row">
        <div class="col s12">
          <p>Nr of downloaded files: 9</p>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <p>Total length of downloaded content: 0 Days and 00:00:00</p>
        </div>
      </div>
      <div class="row">
        <div class="col s12">
          <div class="switch">
            <label>
              Offline
              <input type="checkbox" v-model="isOnline" />
              <span class="lever"></span>
              Online
            </label>
          </div>
        </div>
      </div>
    </setting-card>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Settings as snackTimeSettings } from "@/logic/api/types";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/settings/endpoints";
import SettingCard from "@/components/SettingCard.vue";

@Component({
  components: { SettingCard }
})
export default class Settings extends Vue {
  private storagePath: string = "";
  private storagePathTemp: string = "";
  private mpvPath: string = "";
  private svpPath: string = "";
  private mediaLocation: string = "";
  private isOnline: boolean = false;

  async mounted() {
    let res = await HttpClient.get<snackTimeSettings>(Endpoints.SaveSettings());

    this.storagePath =
      res.payload.system && res.payload.system.fileDir
        ? res.payload.system.fileDir
        : "";
    this.storagePathTemp =
      res.payload.system && res.payload.system.tempFileDir
        ? res.payload.system.tempFileDir
        : "";
    this.mpvPath =
      res.payload.system && res.payload.system.mpvPath
        ? res.payload.system.mpvPath
        : "";
    this.svpPath =
      res.payload.system && res.payload.system.svpPath
        ? res.payload.system.svpPath
        : "";
    this.mediaLocation =
      res.payload.remote && res.payload.remote.mediaServerAddress
        ? res.payload.remote.mediaServerAddress
        : "";
    this.isOnline =
      res.payload.remote && res.payload.remote.isOnline
        ? res.payload.remote.isOnline
        : false;
  }

  async save(): Promise<void> {
    let payload = {
      system: {
        fileDir: this.storagePath,
        tempFileDir: this.storagePathTemp,
        mpvPath: this.mpvPath,
        svpPath: this.svpPath
      },
      remote: {
        isOnline: this.isOnline,
        mediaServerAddress: this.mediaLocation
      }
    } as snackTimeSettings;

    console.log(payload);
    await HttpClient.post(Endpoints.SaveSettings(), payload);
  }
}
</script>

<style scoped lang="less">
.clearfix:after {
  content: " ";
  display: block;
  height: 0;
  clear: both;
}
</style>
