<template>
    <div class="nav-menu">
      <router-link style="text-decoration: none" to="/signup">
        <Button>
          Sign Up
        </Button>
      </router-link>
      <router-link style="text-decoration: none" to="/signin">
        <Button>
          Sign In
        </Button>
      </router-link>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import Button from "@/components/Button.vue"

export default defineComponent({
  name: "AdminNavbarMenu",
  components: {
    Button
  }
})
</script>
