import java.nio.file.Paths

plugins {
    id("java")
}

group = "cn.boxin"
version = "1.0.2-SNAPSHOT"

repositories {
    mavenCentral()
}

val jarName = listOf(
    "NXOpen.jar",
    "NXOpenRemote.jar",
    "NXOpenRun.jar",
    "NXOpenUF.jar",
    "NXOpenUFRemote.jar",
    "NXOpenUFRun.jar",
    "NXOpenUI.jar",
    "NXOpenUIRemote.jar",
    "NXOpenUIRun.jar",
)

dependencies {
    val property = System.getenv("UGII_BASE_DIR")
    val ugBin = Paths.get(property, "NXBIN")
    jarName.forEach {
        implementation(fileTree(ugBin.resolve(it)))
    }

}

tasks.jar {
    manifest {
        attributes(mapOf(Pair("Main-Class", "cn.boxin.ug12.Main")))
    }
}