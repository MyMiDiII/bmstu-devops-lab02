<template>
    <div v-if="this.mode === 'guest'" class="guest">
      <router-link style="text-decoration: none" :to="infoRedirectLink">
        <Button style="height: 70%; width: 200px">Info</Button>
      </router-link>
    </div>
    <div v-else-if="this.mode === 'user-star' || this.mode === 'favorite'" class="user-star">
      <div class="one-center">
        <ServerStar :serverId="serverId" style="height: 70%"/>
      </div>
      <router-link style="text-decoration: none" :to="infoRedirectLink">
        <Button style="height: 70%; width: 200px">Info</Button>
      </router-link>
    </div>
    <div v-else-if="this.mode === 'user-status'" class="user-star">
      <div class="one-center">
        <ServerStatus v-if="serverStatus == 'Accepted'" state="accepted"/>
        <ServerStatus v-else-if="serverStatus == 'Pending'" state="pending"/>
        <ServerStatus v-else-if="serverStatus == 'Rejected'" state="rejected"/>
      </div>
      <router-link style="text-decoration: none" :to="infoRedirectLink">
        <Button style="height: 70%; width: 200px">Info</Button>
      </router-link>
    </div>
    <div v-else-if="this.mode === 'admin'" class="guest">
      <router-link style="text-decoration: none" :to="updateRedirectLink">
        <Button style="height: 100%; width: 200px">Update</Button>
      </router-link>
      <Button @click="deleteServer" style="height: 50%; width: 200px">Delete</Button>
    </div>
    <div v-else-if="this.mode === 'admin-suggest'" class="guest">
      <div class="two-center">
        <ServerButton @click="acceptServer" />
        <ServerButton @click="rejectServer" :accept="false" />
      </div>
      <router-link style="text-decoration: none" :to="infoRedirectLink">
        <Button style="height: 70%; width: 200px">Info</Button>
      </router-link>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from "@/components/Button.vue"
import ServerStatus from "@/components/Servers/ServerStatus.vue"
import ServerStar from "@/components/Servers/ServerStar.vue"
import ServerButton from "@/components/Servers/ServerButton.vue"

import ServerInterface from "@/Interfaces/ServerInterface"


export default defineComponent({
  name: "ServerMenu",
  components: {
    Button,
    ServerStatus,
    ServerStar,
    ServerButton
  },
  props: {
    mode: {
      type: String,
      default: 'guest'
    },
    serverId: {
      type: Number,
      default: 0
    },
    serverStatus: {
      type: Number,
      default: 0
    }
  },
  computed: {
    infoRedirectLink() {
      return `/server-info/${this.serverId}`;
    },
    updateRedirectLink() {
      return `/server-update/${this.serverId}`;
    },
  },
  mounted() {
    // console.log("ServerMenu", this.serverId, this.redirectLink);
  },
  methods: {
    async deleteServer () {
      console.log("ServerDelete", this.serverId);

      const result = await ServerInterface.delete(this.serverId);

      if (result.status == 200) {
        this.$router.go(0);
        this.$notify({
          title: "Success",
          text: "Server Deleted",
        });
      }
    },

    acceptServer() {
      console.log("Accept Server");
      ServerInterface.patchServer(this.serverId, "Accepted").then(res => {console.log(res)});
    },

    rejectServer() {
      console.log("Reject Server");
      ServerInterface.patchServer(this.serverId, "Rejected");
    },
  }
})
</script>

<style scoped>
.guest {
  display: flex;
  justify-content: right;
  align-items: center;
  gap: 70px
}
.one-center {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 75%;
}
.two-center {
  display: flex;
  justify-content: space-around;
  align-items: center;
  width: 75%;
}
.user-star {
  display: flex;
  justify-content: right;
  align-items: center;
  gap: 20%;
}
</style>