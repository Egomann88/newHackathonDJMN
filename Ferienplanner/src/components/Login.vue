<template>
  <div class="min-h-screen bg-[#cbcbcb] py-4">
    <div class="flex flex-wrap overflow-hidden w-1/3 m-auto pt-2 mt-1/2 transform translate-y-1/2">
      <div class="w-full px-4">
        <form @submit="checkLogin()" class="flex flex-wrap w-full overflow-hidden py-4 bg-gray-100 p-4">
          <div class="w-full overflow-hidden py-4">
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Benutzername</p>
                <input class="p-2 rounded-b-sm w-full" type="email" required>
              </div>
            </div>
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Passwort</p>
                <input class="p-2 rounded-b-sm w-full" v-model="myInput" type="password" required>
              </div>
            </div>
          </div>
          <div class="w-full px-4">
            <button class="button w-full my-4 bg-green-300 hover:bg-green-400" type="submit"
              value="submit">Einloggen</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
export default defineComponent({
  components: {},
  setup() { },
  mounted() {
    this.createLS();
  },
  methods: {
    createLS() {
      if (!localStorage.getItem("loggedIn")) localStorage.setItem("loggedIn", "0");
    },

    checkLogin() {
      // check login in database
      localStorage.setItem("loggedIn", "1") //for test
      // fetch('http://localhost:34474/API/User')
      //   .then(res => {
      //     return res.json()
      //   })
      //   .then(data => {
      //     if (data.UserPassword == this.myInput)
      //       localStorage.setItem("loggedIn", "1")
      //   })
    }
  },
});
</script>

<style scoped>

</style>