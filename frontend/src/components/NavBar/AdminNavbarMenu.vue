<template>
    <div class="nav-menu">
      <router-link style="text-decoration: none" to="/servers-control">
        <Button>Servers Control</Button>
      </router-link>
      <router-link style="text-decoration: none" to="/servers-suggested">
        <Button>Suggested Servers</Button>
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
    userId () {
      return auth.getCurrentUser().id;
    }
  },
  methods: {
    logout () {
      auth.logout();
      this.$router.push({ path: '/' })
    },
    
  }
})
</script>
