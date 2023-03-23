<template>
    <body class="container">
        <UpperBackground class="center">
            <UpperBackground class="login-header">
                <router-link style="text-decoration: none" to="/">
                  <BlueText fontSize="var(--middle-text)">
                    ServerING
                  </BlueText>
                </router-link>
                <PinkText fontSize="var(--large-text)">Sign Up</PinkText>
            </UpperBackground>

            <form class="form" @submit.prevent="onSubmit">
              <BlueText fontSize="var(--little-text)">Login</BlueText>
              <InputLine @login="setLogin" name="login" fontSize="var(--tiny-text)"></InputLine>

              <BlueText fontSize="var(--little-text)">Password</BlueText>
              <InputLine @passwordNew="setPassword" name="passwordNew" fontSize="var(--tiny-text)"></InputLine>

              <BlueText fontSize="var(--little-text)">Confirm Password</BlueText>
              <InputLine @passwordConfirm="setPasswordConfirm" name="passwordConfirm" fontSize="var(--tiny-text)"></InputLine>

              <Button type="submit">Sign Up</Button>
            </form>

            <div class="form">
              <BlueText class="text" fontSize="var(--tiny-text)">
                  Have an account?
              </BlueText>
              <PinkText class="text" fontSize="var(--tiny-text)">
                <router-link style="color: var(--magenta)" to="/signin">Sign In</router-link>
              </PinkText>
            </div>
        </UpperBackground>
    </body>
</template>


<script lang="ts">
import { defineComponent } from "vue";
import UpperBackground from "@/components/UpperBackground.vue"
import BlueText from "@/components/BlueText.vue"
import PinkText from "@/components/PinkText.vue"
import InputLine from "@/components/InputLine.vue"
import Button from "@/components/Button.vue"

import auth from "@/authentificationService";
import router from "@/router";

export default defineComponent({
    name: "SignupView",
    components: {
        UpperBackground,
        BlueText,
        PinkText,
        Button,
        InputLine
    },
    data () {
      return {
        login: '',
        password: '',
        passwordConfirm: '',
      }
    },
    methods: {
      async onSubmit() {
        console.log("SignUp:", this.login, this.password, this.passwordConfirm);

        if (this.login == '' || this.password == '' || this.passwordConfirm == '') {
          this.$notify({
            title: "Error",
            text: "Data is Required",
          });
          return;
        }

        if (this.password != this.passwordConfirm) {
          this.$notify({
            title: "Error",
            text: "Passwords are Different",
          });
          return;
        }
        
        const result = await auth.register(this.login, this.password);

        if (result) {
          await auth.login(this.login, this.password);
          router.push("/");
        }
        else {
          this.$notify({
            title: "Error",
            text: "Login is currently Used",
        });
        }
      },
      setLogin(login : string) {
        this.login = login;
      },
      setPassword(password : string) {
        this.password = password;
      },
      setPasswordConfirm(passwordConfirm : string) {
        this.passwordConfirm = passwordConfirm;
      }
    }
})
</script>


<style scoped>
.container {
  display: flex;
  margin: 0;
  width: 100%;
  height: 100%;
  justify-content: center;
  align-items: center;
}
.center {
  /* position: relative; */
  border-radius: 0px 50px 0px 50px;
  height: 75%;
  width: 25%;
  display: grid;
  justify-content: center;
  align-items: center;
  padding: 15px;
}

.login-header {
    align-items: center;
    border-radius: 0px 0px 0px 30px;
    display: flex;
    flex-direction: column;
    overflow: hidden;
    padding: 15px 20px;
    box-shadow: 0px 0px 60px var(--magenta);
}

.text {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
}

.form {
  display: flex;
  flex-direction: column;
  text-align: center;
  gap: 15px;
}
</style>
