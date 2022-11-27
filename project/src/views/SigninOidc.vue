<template>
  <div>Waiting..</div>
</template>

<script>
import {signinRedirectCallback} from "@/service/main";

export default {
  name: "SigninOidc",
  async mounted() {
    try {
      let result = await signinRedirectCallback();
      let returnToUrl = '/';
      if (result.state !== undefined) {
        returnToUrl = result.state;
      }
      this.$router.push({path: returnToUrl});
    } catch (e) {
      this.$router.push({name: 'Unauthorized'});
    }
  }, methods: {
  }

}

</script>