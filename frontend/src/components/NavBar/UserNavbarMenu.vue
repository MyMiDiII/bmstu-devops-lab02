<template>
    <div class="nav-menu">
      <router-link style="text-decoration: none" :to="linkToFavoriteServers">
        <Button>Favorite</Button>
      </router-link>
      <router-link style="text-decoration: none" :to="linkToMyServers">
        <Button>My Servers</Button>
      </router-link>
      <UserPatch @click="logout"> {{userName}} </UserPatch>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from "@/components/Button.vue"
import UserPatch from "@/components/UserPatch.vue"
import auth from "@/authentificationService"

export default defineComponent({
  name: "AdminNavbarMenu",
  components: {
    Button,
    UserPatch
  },
  computed: {
    userName () {
      return auth.getCurrentUser().login;
    },
    linkToFavoriteServers () {
      return `/${auth.getCurrentUser().id}/favorite-servers`
    },
    linkToMyServers () {
      return `/${auth.getCurrentUser().id}/my-servers`
    }
  },
  methods: {
    logout () {
      console.log("Logout");
      auth.logout();
      this.$router.push("/");
      location.reload();
    }
  }
})
</script>
