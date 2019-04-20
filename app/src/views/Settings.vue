<template>
  <div class="container">
    <h3>Snack-Time Settings</h3>
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
        <input
          id="svp-location"
          type="text"
          placeholder="C:\Program Files (x86)\SVP 4\SVPManager.exe"
          v-model="svpPath"
        />
        <label for="svp-location">SVP location</label>
      </div>
    </div>
    <div class="row">
      <div class="col s12">
        <input
          id="media-server-address"
          type="text"
          placeholder="ASd"
          v-model="mediaLocation"
        />
        <label for="media-server-address">
          Snack-Time Media server address
        </label>
      </div>
    </div>
    <div class="row">
      <button class="btn right" @click="save()">Save</button>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Settings as snackTimeSettings } from "@/logic/api/types";
import { HttpClient } from "@/logic/http/httpClient";
import { Endpoints } from "@/logic/api/settings/endpoints";

@Component({
  components: {}
})
export default class Settings extends Vue {
  private storagePath: string = "";
  private storagePathTemp: string = "";
  private mpvPath: string = "";
  private svpPath: string = "";
  private mediaLocation: string = "";

  async mounted() {
    let res = await HttpClient.get<snackTimeSettings>(Endpoints.SaveSettings());

    this.storagePath = res.payload.fileDir;
    this.storagePathTemp = res.payload.tempFileDir;
    this.mpvPath = res.payload.mpvPath;
    this.svpPath = res.payload.svpPath;
    this.mediaLocation = res.payload.mediaServerAddress;
  }

  async save(): Promise<void> {
    let payload = {
      fileDir: this.storagePath,
      tempFileDir: this.storagePathTemp,
      mpvPath: this.mpvPath,
      svpPath: this.svpPath,
      mediaServerAddress: this.mediaLocation
    } as snackTimeSettings;

    await HttpClient.post(Endpoints.SaveSettings(), payload);
  }
}
</script>

<style scoped lang="less"></style>
