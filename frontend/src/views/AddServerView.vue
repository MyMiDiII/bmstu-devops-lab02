<template>
  <NavBarView>
    <div class="container">
      <BlueText class="text" fontSize="var(--huge-text)">
        Add Server
      </BlueText>

      <UpperBackground class="center">
        <form class="center" @submit.prevent="onSubmit">
          <div class="container-row">
            <div class="container-column">
              <PinkText style="text-align: center" fontSize="var(--large-text)">Base</PinkText>

              <BlueText fontSize="var(--little-text)">Name</BlueText>
              <InputLine @name="setName" name="name" fontSize="var(--tiny-text)"></InputLine>

              <BlueText fontSize="var(--little-text)">Ip</BlueText>
              <InputLine @ip="setIp" name="ip" fontSize="var(--tiny-text)"></InputLine>

              <BlueText fontSize="var(--little-text)">Game</BlueText>
              <InputLine @game="setGame" name="game" fontSize="var(--tiny-text)"></InputLine>
            </div>

            <div class="container-column">
              <PinkText style="text-align: center" fontSize="var(--large-text)">Additional</PinkText>

              <BlueText fontSize="var(--little-text)">Hosting</BlueText>
              <Select
                @hosting="setHosting" 
                name="hosting" 
                v-bind:options="hostingOptions" 
                fontSize="var(--tiny-text)"
              />

              <BlueText fontSize="var(--little-text)">Platform</BlueText>
              <Select
                @platform="setPlatform" 
                name="platform" 
                v-bind:options="platformOptions" 
                fontSize="var(--tiny-text)"
              />

              <BlueText fontSize="var(--little-text)">Country</BlueText>
              <Select 
                @country="setCountry" 
                name="country" 
                v-bind:options="countryOptions" 
                fontSize="var(--tiny-text)"
              />
            </div>
          </div>

          <Button type="submit">Add</Button>
        </form>
      </UpperBackground>
    </div>
  </NavBarView>
</template>

<script lang="ts">
import {defineComponent} from 'vue';
import NavBarView from "@/views/NavBarView.vue";
import BlueText from "@/components/BlueText.vue";
import PinkText from "@/components/PinkText.vue";
import UpperBackground from "@/components/UpperBackground.vue";
import FormField from "@/components/FormField.vue"
import FormFieldDropDown from "@/components/FormFieldDropDown.vue"
import FormFieldSelect from "@/components/FormFieldSelect.vue"
import Button from "@/components/Button.vue"
import InputLine from "@/components/InputLine.vue"
import Select from "@/components/Select.vue"

import HostingInterface from "@/Interfaces/HostingInterface"
import PlatformInterface from "@/Interfaces/PlatformInterface"
import CountryInterface from "@/Interfaces/CountryInterface"
import ServerInterface from "@/Interfaces/ServerInterface"
import auth from "@/authentificationService"

import {Server} from "@/Interfaces/ServerInterface"
import router from '@/router';

export default defineComponent({
  name: "AddServer",
  data () {
    return {
      name: '',
      ip: '',
      game: '',
      hostingId: null,
      platformId: null,
      countryId: null,
      hostingOptions: [],
      platformOptions: [],
      countryOptions: [],
    }
  },
  components: {
    NavBarView,
    BlueText,
    PinkText,
    UpperBackground,
    FormField,
    FormFieldDropDown,
    Button,
    FormFieldSelect,
    InputLine,
    Select
  },
  mounted () {
    HostingInterface.getAll().then(json => {this.hostingOptions = json.data});
    PlatformInterface.getAll().then(json => {this.platformOptions = json.data});
    CountryInterface.getAll().then(json => {this.countryOptions = json.data});
  },
  methods: {
    setIp(ip: string) {
      this.ip = ip;
    },
    setName(name: string) {
      this.name = name;
    },
    setGame(game: string) {
      this.game = game;
    },
    setHosting(hostingId: any) {
      console.log("Setter:", hostingId, typeof(hostingId));
      this.hostingId = hostingId;
    },
    setPlatform(platformId: any) {
      this.platformId = platformId;
    },
    setCountry(countryId: any) {
      this.countryId = countryId;
    },
    async onSubmit () {
      console.log("ServerSuggest: Work");

      if (this.name == "" || this.ip == "" || this.game == "" || !this.hostingId || !this.platformId || !this.countryId) {
        this.$notify({
          title: "Error",
          text: "Data is Required",
        });
        return;
      }

      const server: Server = {
        id: 1,
        name: this.name,
        ip: this.ip,
        gameName: this.game,
        rating: 0,
        status: 0,
        platformId: this.platformId,
        countryId: this.countryId,
        hostingId: this.hostingId,
        ownerId: auth.getCurrentUser().id,
      }

      console.log(server);

      const result = await ServerInterface.post(server);

      console.log(result.status);

      if (result.status == 200) {
        router.push("/servers-control");
        this.$notify({
          title: "Success",
          text: "Server is Added",
        });
      }
      else {
        this.$notify({
          title: "Error",
          text: "Ip is currently used",
        });
      }
    }
  }
})
</script>


<style scoped>
.container {
  display: flex;
  flex-direction: column;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
  gap: 30px;
}

.center {
  border-radius: 0px 50px 0px 50px;
  /* height: %; */
  width: 90%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  text-align: center;
  align-items: center;
  padding: 30px;
  gap: 50px;
}

.text {
  display: flex;
  flex-direction: row;
  justify-content: left;
  align-items: left;
  width: 90%
}

.container-row {
  /* display: grid;
  grid-template-columns: 2fr 2fr 2fr 1fr; */
  display: flex;
  /* width: 40%; */
  flex-direction: row;
  gap: 100px;
}

.container-column {
  display: flex;
  flex-direction: column;
  width: 700px;
  gap: 30px;
}
</style>
