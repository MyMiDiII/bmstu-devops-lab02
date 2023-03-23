<template>
    <div class="drop-down-menu">
        <BlueText><slot></slot></BlueText>
        <DropDownButton size=25px />
    </div>
</template>


<script>
import { defineComponent } from 'vue';
import BlueText from "@/components/BlueText.vue"
import DropDownButton from "@/components/DropDownButton.vue"

export default defineComponent({
    name: "DropDownMenu",
    components: {
        BlueText,
        DropDownButton
    }
});
</script>


<style scoped>
    .drop-down-menu {
        display: flex;
        gap: 10px;
    }
</style>
